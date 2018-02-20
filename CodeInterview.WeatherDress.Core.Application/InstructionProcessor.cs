using CodeInterview.WeatherDress.Core.Exceptions;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.io;
using CodeInterview.WeatherDress.Core.Utils;
using System;
using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Application
{
    public class InstructionProcessor:IProcessInstructions
    {

        private IWriter _writer;

        private string weatherInstruction;

        private void SetWeatherInstruction(string instruction)
        {
            weatherInstruction = instruction.Substring(0, instruction.IndexOf(Constants.SPACE_CHAR)).Trim().ToUpper();
        }
        public void Execute(string instruction)
        {
            _writer = new ConsoleWriter();

            try
            {
                SetWeatherInstruction(instruction);
                Application.Bootstrap(weatherInstruction.ToUpper());
                _writer = Application.Container.GetInstance<IWriter>();
                ExecuteDressInstructions(RetrieveDressInstructions(instruction));
                CreateSeparator();
                CreateSeparator();
            }
            catch (InvalidWeatherInstructionException iwie) {
                WriteException(iwie);
            }
            catch (InvalidDressInstructionException idie) {
                WriteException(idie);
            }
            catch (NotSupportedDressException nsde) {
                WriteException(nsde);
            }
            catch (WeatherDressRuleViolatedException wdve) {
                WriteException(wdve);
            }
            catch (Exception ex) {
                WriteException(new Exception(Constants.INVALID_INSTRUCTION));
            }
        }

        private void CreateSeparator()
        {
            _writer.WriteLine("");
        }

        private void ExecuteDressInstructions(List<string>dressInstructionList)
        {
            foreach (var dressInstruction in dressInstructionList)
            {
                IDressInstruction dressCommand = Application.Container.GetInstance<IDressInstruction>(dressInstruction.Trim());
                dressCommand.Execute();
            }
        }

        private void WriteException(Exception ex)
        {
            _writer.Write(Constants.FAIL, ConsoleColor.Red);
            _writer.WriteLine(string.Empty);
            _writer.WriteLine(String.Format("Reason: {0}", ex.Message), ConsoleColor.DarkYellow);
            CreateSeparator();
        }

        private List<string> RetrieveDressInstructions(string instruction)
        {
            instruction = RemoveWeatherInstruction(instruction);
            var dressInstructions = instruction.Split(Constants.COMMA);
            return new List<string>(dressInstructions);
        }

        private string RemoveWeatherInstruction(string instruction)
        {
            return instruction.Remove(0, weatherInstruction.Length).Trim();
        }

    }
}
