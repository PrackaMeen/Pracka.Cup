export type ResponseModel<T, R> = {
    data: T
    eTag: string
    requestBody: R | null
    requestPath: string
}