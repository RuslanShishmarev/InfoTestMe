

export interface CourseCreateModel {
    visible: boolean
    name: string
    description: string
    image: Uint8Array
    onClose: () => void
    reloadAuthorPage: () => void
}

export interface CourseBodyModel {
    id: number
    name: string
    description: string
    image: Uint8Array
}

export interface CourseEditorModel {
    courseId: number
    name: string
    themeList: CourseThemeListModel
    selectedPage: CoursePageModel
}

export interface CourseThemeCreateModel {
    visible: boolean
    courseId: number
    name: string
    onClose: () => void
    reloadCourseThemes: () => void
}

export interface CourseThemeModel {
    id: number
    name: string
    pages: CoursePageShortModel[]
}

export interface CourseThemeListModel {
    courseId: number
    themes: CourseThemeModel[]
    deleteTheme: () => void;
}

export interface CoursePageShortModel {
    id: number
    themeId: number
    name: string
}

export interface CoursePageModel {
    id: number
    themeId: number
    name: string
    link: string
    audioFileName: string
    audioFile: Uint8Array
    blocks: CourseBlockModel[]
}

export interface CourseBlockModel {
    id: number
    pageId: number
    text: string
    image: Uint8Array
}