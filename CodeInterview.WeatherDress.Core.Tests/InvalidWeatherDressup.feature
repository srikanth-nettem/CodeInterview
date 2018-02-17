Feature: InvalidWeatherDressing
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@integration
Scenario: Duplicate DressOn 
	Given the weather is "HOT"  
	When I wear the following in the given order
	| Dress       |
	| Pajamas_Off |
	| PantsOn     |
	| PantsOn     |
	Then the dressing should fail

@integration
Scenario: Dress with Socks in Hot Weather
	Given the weather is "HOT"  
	When I wear the following in the given order
	| Dress       |
	| Pajamas_Off |
	| PantsOn     |
	| SocksOn     |
	Then the dressing should fail

@integration
Scenario: Dress with Jacket in Hot Weather 
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
	Then the dressing should fail

@integration
Scenario: No Complete Dressing (miss to wear atleast one dressing) 
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
	Then the dressing should fail

@integration
Scenario: Dress without PajamasOff
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
	Then the dressing should fail