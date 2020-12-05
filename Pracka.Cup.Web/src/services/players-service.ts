import * as playersEndpoints from "../api/endpoints/players-endpoints";

export async function getAllPlayers(): Promise<any[]> {
    var playerDtos = await playersEndpoints.getAllPlayers()

    return playerDtos
}