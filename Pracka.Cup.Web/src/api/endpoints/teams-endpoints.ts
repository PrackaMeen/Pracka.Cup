import { getHttpHandler } from '../handler'
import { TeamDto } from '../models/team-dto'
import { ResponseModel } from '../response-model'

export async function getAllTeams(): Promise<TeamDto[]> {
    try {
        var result = await getHttpHandler({
            relativeUrl: 'http://localhost:7071/api/teams'
        })

        var response: ResponseModel<TeamDto[], null> = await result.json()
        return response.data.map<TeamDto>((team) => {
            return {
                ...team
            }
        })
    }
    catch (ex) {
        console.error(ex)
        return []
    }
}