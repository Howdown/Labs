// ReSharper disable InconsistentNaming
namespace FunctionInTheConsoleTests
{
    using System;
    using System.Collections.Generic;
    using FunctionInTheConsole;
    using FunctionInTheConsole.Builders;
    using FunctionInTheConsole.Command;
    using FunctionInTheConsole.Functions;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    public class AddLinearFunctionBuilderStab : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var regexForName = new Regex(@"\w+");
            var regexForArguments = new Regex(@"(-?\d+(,\d+)?)");
            var regForFunction = new Regex(@"\w+\((-?\d+(,\d+)?) (-?\d+(,\d+)?)\)$");
            var regexForParameters = new Regex(@"\((-?\d+(,\d+)?) (-?\d+(,\d+)?)\)$");
            var function = regForFunction.Match(input).ToString();
            var name = regexForName.Match(function).ToString();
            var parameters = regexForParameters.Match(function).ToString();
            var arguments = regexForArguments.Matches(parameters);
            var firstArgument = Convert.ToDouble(arguments[0].ToString());
            var secondArgument = Convert.ToDouble(arguments[1].ToString());
            var linearFunction = new LinearFunction(firstArgument, secondArgument);
            return new AddFunctionCommandStab(name, linearFunction);
        }
    }

    public class CalculateFunctionBuilderStab : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            var name = "Linear";
            var argument = 3;
            return new CalculateFunctionCommandStab(name, argument);
        }
    }

    public class DeleteFunctionBuilderStab : ICommandBuilder
    {
        public ICommand BuildCommand(string input)
        {
            return new DeleteFunctionCommandStab("Linear");
        }
    }

    public class LinearFunctionStab : FunctionBase
    {
        private readonly double firstArgument;

        private readonly double secondArgument;

        public LinearFunctionStab(double first, double second)
        {
            this.firstArgument = first;
            this.secondArgument = second;
        }

        public override double Calculate(double value)
        {
            var result = this.secondArgument;
            result += this.firstArgument * value;
            return result;
        }

        public override FunctionBase GetDerivative()
        {
            throw new System.NotImplementedException();
        }
    }

    public class DeleteFunctionCommandStab : CommandResultHelperStab
    {
        private readonly string name;

        public DeleteFunctionCommandStab(string name)
        {
            this.name = name;
        }

        public override CommandResult Apply(IFunctionsStorage storage)
        {
            try
            {
                if (!storage.ContainsFunctions(this.name))
                {
                    return this.Failure("Function with this name is missing");
                }
                storage.DeleteFunction(this.name);
                return this.Success();
            }
            catch (Exception e)
            {
                return Failure(e.Message + e.TargetSite);
            }
        }
    }

    public class CalculateFunctionCommandStab : CommandResultHelperStab
    {
        private readonly string name;
        private readonly double argument;

        public CalculateFunctionCommandStab(string name, double argument)
        {
            this.name = name;
            this.argument = argument;
        }

        public override CommandResult Apply(IFunctionsStorage storage)
        {
            return storage.ContainsFunctions(this.name) ? new CommandResult(true, storage.CalculateFunction(this.name, this.argument).ToString())
                       : new CommandResult(false, "Function with this name is missing");
        }
    }

    public class AddFunctionCommandStab : CommandResultHelperStab
    {
        private readonly string nameFunction;

        private readonly FunctionBase function;

        public AddFunctionCommandStab(string nameFunction, FunctionBase function)
        {
            this.nameFunction = nameFunction;
            this.function = function;
        }

        public override CommandResult Apply(IFunctionsStorage storage)
        {
            if (storage.ContainsFunctions(this.nameFunction))
            {
                return this.Failure("Function with the same name already exists");
            }

            storage.AddFunction(this.nameFunction, this.function);
            return this.Success();
        }
    }

    public abstract class CommandResultHelperStab : ICommand
    {
        public CommandResult Success(string message = null)
        {
            var result = new CommandResult(true, message);
            return result;
        }

        public CommandResult Failure(string message)
        {
            var result = new CommandResult(false, message);
            return result;
        }

        public abstract CommandResult Apply(IFunctionsStorage storage);
    }

    public class FunctionsStorageStab : IFunctionsStorage
    {
        private readonly Dictionary<string, FunctionBase> functions;

        public FunctionsStorageStab()
        {
            this.functions = new Dictionary<string, FunctionBase>();
        }

        public void AddFunction(string name, FunctionBase viewFunction)
        {
            this.functions.Add(name, viewFunction);
        }

        public void DeleteFunction(string name)
        {
            throw new System.NotImplementedException();
        }

        public double CalculateFunction(string name, double value) => this.functions[name].Calculate(value);

        public FunctionBase GetDerivativeFunction(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsFunctions(string name)
        {
            return this.functions.ContainsKey(name);
        }

        public FunctionBase GetFunction(string name)
        {
            return this.functions[name];
        }
    }



    [TestFixture]
    public class InterpreterTests
    {
        [Test]
        public void InputCommand_Interpreter_ResultMustBeMessageAboutTheAbsenceOfSuchBuilder()
        {
            var command = "add linear linear(3  2)";
            var builder =
                new Dictionary<string, Func<ICommandBuilder>>()
                {
                    [@"^add linear \w+\((-?\d+(,\d+)?) (-?\d+(,\d+)?)\)$"] = () => new AddLinearFunctionBuilderStab()
                };
            var storage = new FunctionsStorageStab();
            var interpreter = new Interpreter(storage, builder);

            var result = interpreter.SearchMatches(command);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(result.Message, "the command is entered incorrectly");
                Assert.IsFalse(result.Identifier);
            });
        }

        [Test]
        public void InputCommand_Interpreter_ResultMustBeIsTrue()
        {
            var command = "add linear linearA(2 3,1)";
            var builder =
                new Dictionary<string, Func<ICommandBuilder>>()
                {
                    [@"^add linear \w+\((-?\d+(,\d+)?) (-?\d+(,\d+)?)\)$"]
                        = () => new AddLinearFunctionBuilderStab()
                };
            var storage = new FunctionsStorageStab();
            var interpreter = new Interpreter(storage, builder);

            var result = interpreter.SearchMatches(command);

            Assert.Multiple(() =>
            {
                Assert.IsNull(result.Message);
                Assert.IsTrue(result.Identifier);
            });
        }

        [Test]
        public void CalculateFunction_Interpreter_ResultMustBeSumOfNumber()
        {
            var command = "calc Linear(2)";
            var builder =
                new Dictionary<string, Func<ICommandBuilder>>()
                {
                    [@"^calc \w+\((-?\d+(,\d+)?)\)$"]
                        = () => new CalculateFunctionBuilderStab()
                };
            var storage = new FunctionsStorageStab();
            var interpreter = new Interpreter(storage, builder);

            storage.AddFunction("Linear", new LinearFunctionStab(2.3, 3));
            var result = interpreter.SearchMatches(command);

            Assert.Multiple(
                () =>
            {
                Assert.AreEqual(result.Message, "9,9");
                Assert.IsTrue(result.Identifier);
            });
        }

        [Test]
        public void NotImplementedStorageMethod_Interpreter_ResultMustBeExeption()
        {
            var command = "del Linear";
            var message = "Метод или операция не реализована.Void DeleteFunction(System.String)";
            var builder =
                new Dictionary<string, Func<ICommandBuilder>>()
                {
                    [@"^del \w+$"]
                        = () => new DeleteFunctionBuilderStab()
                };
            var storage = new FunctionsStorageStab();
            var interpreter = new Interpreter(storage, builder);

            storage.AddFunction("Linear", new LinearFunctionStab(3, 2));
            var result = interpreter.SearchMatches(command);

            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(result.Message, message);
                    Assert.IsFalse(result.Identifier);
                }
                );
        }
    }
}
