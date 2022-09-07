# FootballScoreBoard
Score board project for Optima 

This is a simple project with its Tests library. There's an extension to avoid you to include thye functionality to yout netCore project.
I wanted to make it in Net Standard, but I think that it will make ugly the dependency injection module.

You can find the ServiceCollectionExtensions at Domain/Extensions folder.

I've made a service called ScoreBoardService, that implements the 4 methods requested by Optima. All of them are async because I don't think that
using an inmemory storage is a good option, so I prepared it to have read/write operations to a database (another implementation should be writed).

You will find some [assembly] attributes to allow to test the internal classes. 

ASSUMPTIONS
- Every match should have an ID. I make it an string, because it deserialize anything, but could be a Guid or a long instead.
- If you want to test the results, you can execute the test called : GetSummary_ValidMatches_ValidOrderedMatchesSummary()
- I don't writed the results to any output because the requested statement says that we only need to GET. 
