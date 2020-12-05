import React from "react"

type SvgContainerProps = {
    src: string
    alt?: string
    style?: React.CSSProperties
    className?: string
}

export default function SvgContainer(props: SvgContainerProps) {
    return (
        <img {...props} />
    )
}