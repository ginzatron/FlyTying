db.getCollection("Recipe").aggregate(

	// Pipeline
	[
		// Stage 1
		{
			$facet: {
			    "HookClassification": [
			        {$sortByCount: "$Hook.Classification"}
			    ],
			    
			    "Eye" :[
			        {$sortByCount: "$Hook.Eye"}
			    ],
			    
			    "Shank":[
			        {$sortByCount: "$Hook.Shank"}
			    ],
			    
			    "Bend":[
			        {$sortByCount: "$Hook.Bend"}
			    ],
			    
			    "Gap":[
			        {$sortByCount: "$Hook.Gap"}
			    ],
			    
			    "Strength":[
			        {$sortByCount: "$Hook.Strength"}
			    ]
			}
		},
	],

	// Options
	{
		collation: {
			
			locale: "en_US",
		}
	}

	// Created with Studio 3T, the IDE for MongoDB - https://studio3t.com/

);
