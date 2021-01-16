export function useFacets() {

  async function getFacets() {
    const response = await fetch(`https://localhost:44352/api/recipes/facet`, {
      headers: {
        accept: "application/json",
      },
    });
    let data = await response.json();
    data = JSON.parse(data);

    const facetlist = [];
    for (const item in data) {
      facetlist.push(...data[item]);
    }

    return facetlist;
  }

  return {
    getFacets,
  };
  
}
