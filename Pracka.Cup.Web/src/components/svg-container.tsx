import React from "react"

type SvgContainerProps = {
    src: string
    alt?: string
    style?: React.CSSProperties
    className?: string
}

export default function SvgContainer(props: SvgContainerProps) {
    const alt = props.alt ?? ''

    return (
        <img {...props} alt={alt} />
    )
}