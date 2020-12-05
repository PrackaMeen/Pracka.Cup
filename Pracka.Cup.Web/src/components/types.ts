type SiteMenuClasses = 'root' | 'containedPrimary' | 'link'
export type SiteMenuProps = {
    options: Array<{
        label: string
        linkTo: string
    }>
    classes?:Partial<Record<SiteMenuClasses, string>>
}