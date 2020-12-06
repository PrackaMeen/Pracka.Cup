import { getHttpHandler } from '../handler'
import { PlayerDto } from '../models/player-dto'
import { ResponseModel } from '../response-model'

export async function getAllPlayers(): Promise<PlayerDto[]> {
    try {
        var result = await getHttpHandler({
            relativeUrl: '/api/players'
        })

        var response: ResponseModel<PlayerDto[], null> = await result.json()
        return response.data.map<PlayerDto>((player) => {
            return {
                ...player
            }
        })
    }
    catch (ex) {
        console.error(ex)
        return []
    }
}