import * as teamsEndpoints from "../api/endpoints/teams-endpoints";

export async function getAllTeams(): Promise<any[]> {
    var teamDtos = await teamsEndpoints.getAllTeams()

    return teamDtos
}