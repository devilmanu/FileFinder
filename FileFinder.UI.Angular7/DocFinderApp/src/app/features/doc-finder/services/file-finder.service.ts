import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IFileFindByTextResponse } from 'src/app/models/FileFindByTextResponse';
import { environment } from '../../../../environments/environment'

@Injectable()
export class FileFinderService {

  constructor(private http: HttpClient) {

  }

  getFileByText(text : string){
    return this.http.get<IFileFindByTextResponse[]>(environment.apiUrl + "/file/", {params : { content : text }})
  }

  uploadFile(uuid : string ,name: string, value: string | Blob, fileName?: string){
    const formData = new FormData();
    formData.append(name, value, fileName);
    return this.http.post(`${environment.apiUrl}/${uuid}`, formData, {reportProgress : true})
  }
}
