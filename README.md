# Trustpilot’s code challenge 

## Selected Challenge is Pony Challenge

[Challenge URL](https://ponychallenge.trustpilot.com/index.html)

Pony Valid Names:

[Reference](https://mylittlepony.hasbro.com/en-us/characters/ponies)

|# |Pont Valid Name		|
|--|--------------------|
|0 |Twilight Sparkle	|
|1 |Fluttershy			|
|2 |Applejack			|
|3 |Rainbow Dash		|
|4 |Rarity				|
|5 |Pinkie Pie			|
|6 |Princess Celestia	|
|7 |Princess Luna		|
|8 |Princess Cadance	|
|9 |Spike the Dragon	|
|10|Sunset Shimmer		|
|11|Flash Sentry		|
|12|Photo Finish		|
|12|Cutie Mark Crusaders|
|13|Discord				|
|14|Spitfire & Soarine	|
|15|Big McIntosh		|
|16|Granny Smith		|
|17|Cherilee			|
|18|Sapphire Shores		|
|19|Tirek				|
|20|Songbird Serenade	|
|21|Tempest Shadow		|
|22|Grubber				|
|23|Storm King			|
|24|Capper Dapperpaws	|
|25|Captain Calaeno		|
|26|Princess Sky Star	|
|27|Queen Novo			|


### How to Calculate the location of the Object (Pony, Domokun or EndPoint)
The location is the number of cells from the beginging till the location itself.
For Example: if the Pony's location is 121 and the Maze Dimention is 15 * 25 (Width * Height),
then to get the location, you should do the following:
* Divide 121 / 15 (Maze's width) = 8.066666 (8 here indicate the whole rows before the exact location)
* Subtract the number before the decimal point, so it will be 0.066666
* Multiply it with the maze width (15), the result is 1
* The Pony's location is in the 9th row and the 2nd column ((.0666666 * 15) + 1)

