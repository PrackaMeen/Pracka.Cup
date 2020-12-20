import { getHttpHandler } from '../handler'
import { StatisticsRankDto } from "../models/statistics-rank-dto"
import { ResponseModel } from '../response-model'

export async function getAllStatistics(): Promise<StatisticsRankDto[]> {
    try {
        var result = await getHttpHandler({
            relativeUrl: '/api/statistics'
        })

        var response: ResponseModel<StatisticsRankDto[], null> = await result.json()
        return response.data.map<StatisticsRankDto>((player) => {
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