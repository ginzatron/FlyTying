export function useFacets() {
  async function getFacets() {
    const response = await fetch(`https://localhost:44352/api/recipes/facet`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        accept: "application/json",
      },
      body: JSON.stringify({
        "patterns": ["Steelhead", "Hopper"],
        "patternNames": ["RibHaresEar2", "RoyalWulff1"]
      })
    });
    const data = await response.json();
    return data;
  }

  return {
    getFacets
  };
}
