interface httpHandlerArgs<T> {
    relativeUrl: string
    type: 'GET' | 'POST'
    body?: T
}

export default function httpHandler<T>(args: httpHandlerArgs<T>) {
    return fetch(args.relativeUrl, {
        body: JSON.stringify(args.body),
        method: args.type
    })
}

export function getHttpHandler({ relativeUrl }: { relativeUrl: string }) {
    return httpHandler<void>({
        relativeUrl,
        type: 'GET'
    })
}

export function postHttpHandler<T>({ relativeUrl, data }: { relativeUrl: string, data: T }) {
    return httpHandler({
        relativeUrl,
        type: 'POST',
        body: data
    })
}