using CodeInterview.WeatherDress.Core.Exceptions;
using CodeInterview.WeatherDress.Core.Instructions;
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
            weatherInstruction = instruction.Substring(0, instruction.IndexOf(' ')).Trim().ToUpper();
        }
        public void Execute(string instruction)
        {
            _writer = new ConsoleWriter();

            try
            {
                SetWeatherInstruction(instruction);
                Application.Bootstrap(weatherInstruction.ToUpper());
                _writer = Application.Container.GetInstance<IWriter>();
                var dressInstructionList = RetrieveDressInstructions(instruction);
                    
                foreach (var dressInstruction in dressInstructionList)
                {
                    IInstruction dressCommand = Application.Container.GetInstance<IInstruction>(dressInstruction.Trim());
                    dressCommand.Execute();
                }

                _writer.WriteLine("");
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
                WriteException(ex);
            }
        }

        private void WriteException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _writer.Write("fail");
            _writer.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            _writer.WriteLine(ex.Message);
        }

        private List<string> RetrieveDressInstructions(string instruction)
        {
            instruction = RemoveWeatherInstruction(instruction);
            var dressInstructions = instruction.Split(',');
            return new List<string>(dressInstructions);
        }

        private string RemoveWeatherInstruction(string instruction)
        {
            return instruction.Remove(0, weatherInstruction.Length).Trim();
        }

    }
}
