export async function getCharsData(url) {
    try {
        let response = await fetch(url)
        if (!response.ok) {
            throw new Error(`HTTP error: ${response.status}`)
        }
        return await response.json()
    } catch (error) {
        console.error('Error fetching data:', error)
        return []
    }
}
