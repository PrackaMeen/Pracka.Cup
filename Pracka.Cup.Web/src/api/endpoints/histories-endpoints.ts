import { getHttpHandler, postHttpHandler } from '../handler'
import { HistoryDto } from '../models/history-dto'
import { CreateHistoryDto } from '../models/create-history-dto'
import { ResponseModel } from '../response-model'

export async function getAllHistories(): Promise<HistoryDto[]> {
    try {
        var result = await getHttpHandler({
            relativeUrl: 'http://localhost:7071/api/histories'
        })

        var response: ResponseModel<HistoryDto[], null> = await result.json()
        return response.data.map<HistoryDto>((history) => {
            return {
                ...history,
                gameDateUTC: new Date(history.gameDateUTC)
            }
        })
    }
    catch (ex) {
        console.error(ex)
        return []
    }
}

export async function createHistory(createHistory: CreateHistoryDto): Promise<HistoryDto | undefined> {
    try {
        var result = await postHttpHandler({
            relativeUrl: 'http://localhost:7071/api/histories/create',
            data: createHistory
        })

        var response: ResponseModel<HistoryDto, null> = await result.json()
        return {
            ...response.data,
            gameDateUTC: new Date(Date.parse(`${response.data.gameDateUTC}`))
        }
    }
    catch (ex) {
        console.error(ex)
        return undefined
    }
}