export interface Client{
    Id?: number,
    nome: string,
    sobrenome: string,
    email: string,
    dataNascimento?: Date,
    escolaridade?: Escolaridade
}
export enum Escolaridade{
    Infantil = 1,
    Fundamental = 2,
    Medio = 3,
    Superior = 4
}