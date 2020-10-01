db.getCollection("Recipe").aggregate(

	// Pipeline
	[
		// Stage 1
		{
			$facet: {
			    "Weight": [
			        {$sortByCount: "$Thread.Weight"}
			    ],
			    
			    "Denier": [
			        {$sortByCount: "$Thread.Denier"}
			    ],
			    
			    "Color": [
			        {$sortByCount: "$Thread.Color"}
			    ]
			}
		},

	]

	// Created with Studio 3T, the IDE for MongoDB - https://studio3t.com/

);
