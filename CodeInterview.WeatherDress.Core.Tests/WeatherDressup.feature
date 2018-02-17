Feature: Weather Dressing
	In order to get ready for a trip
	As a Traveller
	I want to dress appropriately for the given weather.

@integration
Scenario: Dress accordingly For Hot Weather
	Given the weather is "HOT"  
	When I wear the following in the given order
	| Dress       |
	| Pajamas_Off |
	| PantsOn     |
	| ShirtOn     |
	| HeadwearOn  |
	| FootwearOn  |
	| LeaveHouse  |
	Then I can leave house
		But shirt I put on should be "shirt"
		And pants I put on should be "shorts"
		And headwear should be "sun visor"
		And footweear should be "sandals"

@integration
Scenario: Dress accordingly For Cold Weather
	Given the weather is "COLD"  
	When I wear the following in the given order
	| Dress       |
	| Pajamas_Off |
	| PantsOn     |
	| SocksOn     |
	| ShirtOn     |
	| HeadwearOn  |
	| JacketOn    |
	| FootwearOn  |
	| LeaveHouse  |
	Then I can leave house
		But shirt I put on should be "t-shirt"
		And pants I put on should be "pants"
		And headwear should be "hat"
		And footweear should be "boots"
		And should put on Jacket
		And should put on Socks