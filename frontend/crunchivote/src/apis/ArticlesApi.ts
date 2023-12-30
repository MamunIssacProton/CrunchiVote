const BaseUrl = "http://localhost:5254"; // Replace with your actual API endpoint

export const get = async (page:number) => {
  try {
    const response = await fetch(`${BaseUrl}/articles?page=${page}`);
    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};