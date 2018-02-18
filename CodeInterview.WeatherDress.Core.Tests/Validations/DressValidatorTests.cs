using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Validations;
using CodeInterview.WeatherDress.Core.Rules;
using CodeInterview.WeatherDress.Core.State;
using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Tests.Validations
{
    [Trait("Category", "unit")]
    public class DressValidatorTests
    {
        private readonly IDressValidator _dressValidator;
        private readonly IRulesEngine _rulesEngine;
        private readonly IStateManager _stateManager;


        public static IEnumerable<object[]> RulesData1 = new List<object[]>(){
                                                                new object[] {
                                                                                new Dictionary<DressCommand, bool>()
                                                                                {
                                                                                    {DressCommand.Pajamas_Off,true },
                                                                                    {DressCommand.ShirtOn, true }
                                                                                },
                                                                                new {State=DressCommand.Pajamas_Off, flag=true},
                                                                                new {State=DressCommand.ShirtOn, flag=true}
                                                                              },
                                                                new object[] {
                                                                                new Dictionary<DressCommand, bool>()
                                                                                {
                                                                                    {DressCommand.Pajamas_Off,true },
                                                                                    {DressCommand.ShirtOn, false }
                                                                                },
                                                                                new {State=DressCommand.Pajamas_Off, flag=true},
                                                                                new {State=DressCommand.ShirtOn, flag=false}

                                                                              }
                                                                            };

        public static IEnumerable<object[]> RulesData2 = new List<object[]>(){
                                                                new object[] {
                                                                                new Dictionary<DressCommand, bool>()
                                                                                {
                                                                                    {DressCommand.Pajamas_Off,true },
                                                                                    {DressCommand.ShirtOn, true }
                                                                                },
                                                                                new {State=DressCommand.Pajamas_Off, flag=true},
                                                                                new {State=DressCommand.ShirtOn, flag=false},
                                                                              },
                                                                new object[] {
                                                                                new Dictionary<DressCommand, bool>()
                                                                                {
                                                                                    {DressCommand.Pajamas_Off,false },
                                                                                    {DressCommand.ShirtOn, true }
                                                                                },
                                                                                new {State=DressCommand.Pajamas_Off, flag=false},
                                                                                new {State=DressCommand.ShirtOn, flag=false}
                                                                              }
                                                                            };

        public DressValidatorTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _rulesEngine = Substitute.For<IRulesEngine>();
            _dressValidator = new DressValidator(_rulesEngine, _stateManager);
        }

        [Theory]
        [MemberData(nameof(RulesData1))]
        public void ShouldReturnTrueIfRulesAreMet(IDictionary<DressCommand, bool> rules, dynamic state1, dynamic state2)
        {
            //given
            _rulesEngine.GetRule(DressCommand.JacketOn).Returns(rules);
            
            _stateManager.isStateVisited((DressCommand)state1.State).Returns((bool)state1.flag);
            _stateManager.isStateVisited((DressCommand)state2.State).Returns((bool)state2.flag);

            Assert.True(_dressValidator.isValid(DressCommand.JacketOn));
        }

        [Theory]
        [MemberData(nameof(RulesData2))]
        public void ShouldReturnFalseIfRulesAreNotMet(IDictionary<DressCommand, bool> rules, dynamic state1, dynamic state2)
        {
            //given
            _rulesEngine.GetRule(DressCommand.JacketOn).Returns(new Dictionary<DressCommand, bool>()
            {
                {DressCommand.Pajamas_Off,true },
                {DressCommand.ShirtOn, true }
            });
            _stateManager.isStateVisited((DressCommand)state1.State).Returns((bool)state2.flag);
            _stateManager.isStateVisited((DressCommand)state2.State).Returns((bool)state2.flag);

            Assert.False(_dressValidator.isValid(DressCommand.JacketOn));
        }

    }
}
