export interface IFileFindByTextResponse
{
    id : string;
    highlights : Array<string>
    title : string
    imageUrl : string
} 

export class FileFindByTextResponse implements IFileFindByTextResponse
{
    imageUrl: string;
    id : string;
    highlights : Array<string>
    title : string
}   