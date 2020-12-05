import { TeamDto } from "./team-dto";

export type PlayerDto = {
    id: number
    firstName: string
    lastName: string
    nickname: string
    selectedTeam: TeamDto
}