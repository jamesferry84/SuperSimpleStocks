
# Super Simple Stocks

Console Application

Language: C#

Third Party Libs: Log4Net (using NuGet and is included in packages.config)

Log file will be in bin directory named: supersimplestocks.log

Example Output:

Calculating Dividend Yield....


Symbol: TEA

Type: Common

Last Dividend: 0

Fixed Dividend: 0

Par Value: 100

Dividend Yield: 0

P/E Ratio:

VWSP: 0


Symbol: POP
Type: Common
Last Dividend: 8
Fixed Dividend: 0
Par Value: 100
Dividend Yield: 0.0784313725490196
P/E Ratio:
VWSP: 0


Symbol: ALE
Type: Common
Last Dividend: 23
Fixed Dividend: 0
Par Value: 60
Dividend Yield: 0.225490196078431
P/E Ratio:
VWSP: 0


Symbol: GIN
Type: Preferred
Last Dividend: 8
Fixed Dividend: 0.02
Par Value: 100
Dividend Yield: 0.0196078431372549
P/E Ratio:
VWSP: 0


Symbol: JOE
Type: Common
Last Dividend: 13
Fixed Dividend: 0
Par Value: 250
Dividend Yield: 0.127450980392157
P/E Ratio:
VWSP: 0
Completed Calculating Dividend Yield



Calculating P/E Ratio....


Symbol: TEA
Type: Common
Last Dividend: 0
Fixed Dividend: 0
Par Value: 100
Dividend Yield: 0
P/E Ratio:
VWSP: 0


Symbol: POP
Type: Common
Last Dividend: 8
Fixed Dividend: 0
Par Value: 100
Dividend Yield: 0.0784313725490196
P/E Ratio: 12.75
VWSP: 0


Symbol: ALE
Type: Common
Last Dividend: 23
Fixed Dividend: 0
Par Value: 60
Dividend Yield: 0.225490196078431
P/E Ratio: 4.43478260869565
VWSP: 0


Symbol: GIN
Type: Preferred
Last Dividend: 8
Fixed Dividend: 0.02
Par Value: 100
Dividend Yield: 0.0196078431372549
P/E Ratio: 12.75
VWSP: 0


Symbol: JOE
Type: Common
Last Dividend: 13
Fixed Dividend: 0
Par Value: 250
Dividend Yield: 0.127450980392157
P/E Ratio: 7.84615384615385
VWSP: 0
Completed P/E Ratio



Calculating Volume Weighted Stock Price for all trades placed in last 15 minutes....


Symbol: TEA
Type: Common
Last Dividend: 0
Fixed Dividend: 0
Par Value: 100
Dividend Yield: 0
P/E Ratio:
VWSP: 50


Symbol: POP
Type: Common
Last Dividend: 8
Fixed Dividend: 0
Par Value: 100
Dividend Yield: 0.0784313725490196
P/E Ratio: 12.75
VWSP: 20


Symbol: ALE
Type: Common
Last Dividend: 23
Fixed Dividend: 0
Par Value: 60
Dividend Yield: 0.225490196078431
P/E Ratio: 4.43478260869565
VWSP: 0


Symbol: GIN
Type: Preferred
Last Dividend: 8
Fixed Dividend: 0.02
Par Value: 100
Dividend Yield: 0.0196078431372549
P/E Ratio: 12.75
VWSP: 0


Symbol: JOE
Type: Common
Last Dividend: 13
Fixed Dividend: 0
Par Value: 250
Dividend Yield: 0.127450980392157
P/E Ratio: 7.84615384615385
VWSP: 0
Completed Calculating Volume Weighted Stock Price



Record Trade
Stock:
Symbol: TEA
Type: Common
Last Dividend: 0
Fixed Dividend: 0
Par Value: 100
Dividend Yield: 0
P/E Ratio:
VWSP: 50
TimeOfTrade: 23/02/2017 22:35:31
QTY: -100
Price: 100
Direction: Sell

##ALL TRADES##


Stock:
Symbol: TEA
Type: Common
Last Dividend: 0
Fixed Dividend: 0
Par Value: 100
Dividend Yield:
P/E Ratio:
VWSP: 0
TimeOfTrade: 23/02/2017 22:35:31
QTY: 100
Price: 50
Direction: Buy



Stock:
Symbol: POP
Type: Common
Last Dividend: 8
Fixed Dividend: 0
Par Value: 100
Dividend Yield:
P/E Ratio:
VWSP: 0
TimeOfTrade: 23/02/2017 22:35:31
QTY: 50
Price: 20
Direction: Buy



Stock:
Symbol: TEA
Type: Common
Last Dividend: 0
Fixed Dividend: 0
Par Value: 100
Dividend Yield: 0
P/E Ratio:
VWSP: 50
TimeOfTrade: 23/02/2017 22:35:31
QTY: -100
Price: 100
Direction: Sell

##############
Completed Record Trade



Calculating GBCE All Share Index....
GBCE All Share Index = 1
Completed GBCE All Share Index


