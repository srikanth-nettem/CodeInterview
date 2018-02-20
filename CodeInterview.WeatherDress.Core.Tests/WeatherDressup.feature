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
		But shirt I put on should be "t-shirt"
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
		But shirt I put on should be "shirt"
		And pants I put on should be "pants"
		And headwear should be "hat"
		And footweear should be "boots"
		And should put on Jacket
		And should put on Socks

@integration
@ignore
Scenario: Duplicate DressOn is invalid.
	Given the weather is "HOT"  
	When I wear the following in the given order
	| Dress       |
	| Pajamas_Off |
	| PantsOn     |
	| PantsOn     |
	Then the dressing should fail

@integration
@ignore
Scenario: Dress with Socks in Hot Weather is invalid.
	Given the weather is "HOT"  
	When I wear the following in the given order
	| Dress       |
	| Pajamas_Off |
	| PantsOn     |
	| SocksOn     |
	Then pants I put on should be "shorts"
		But the dressing should fail

@integration
@ignore
Scenario: Dress with Jacket in Hot Weather is invalid.
	Given the weather is "HOT"  
	When I wear the following in the given order
	| Dress       |
	| Pajamas_Off |
	| PantsOn     |
	| ShirtOn     |
	| HeadwearOn  |
	| JacketOn    |
	| FootwearOn  |
	| LeaveHouse  |
	Then pants I put on should be "shorts"
		And shirt I put on should be "shirt"
		And headwear should be "sun visor"
		But the dressing should fail

@integration
@ignore
Scenario: No Complete Dressing (miss to wear atleast one dressing) is invalid.
	Given the weather is "COLD"  
	When I wear the following in the given order
	| Dress       |
	| Pajamas_Off |
	| PantsOn     |
	| SocksOn     |
	| ShirtOn     |
	| HeadwearOn  |
	| JacketOn    |
	| LeaveHouse  |
	Then pants I put on should be "pants"
		And should put on Socks
		And shirt I put on should be "t-shirt"
		And headwear should be "hat"
		And should put on Jacket
		But the dressing should fail

@integration
@ignore
Scenario: Dress without PajamasOff is invalid.
	Given the weather is "HOT"  
	When I wear the following in the given order
	| Dress      |
	| PantsOn    |
	| ShirtOn    |
	| HeadwearOn |
	| FootwearOn |
	| LeaveHouse |
	Then the dressing should fail