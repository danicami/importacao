import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Importacao } from '../model/importacao';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = 'http://localhost:4200/api/Importacao';

@Injectable({
  providedIn: 'root'
})
export class ImportacaoApiService {

  constructor(private http: HttpClient) { }

  getImportacoes (): Observable<Importacao[]> {
    return this.http.get<Importacao[]>(apiUrl)
      .pipe(
        tap(clientes => console.log('leu as importacoes')),
        catchError(this.handleError('getImportacoes', []))
      );
  }

  
  getImportacao(id: number): Observable<Importacao> {
    const url = `${apiUrl}/${id}`;
    return this.http.get<Importacao>(url).pipe(
      tap(_ => console.log(`leu a importacao id=${id}`)),
      catchError(this.handleError<Importacao>(`getImportacao id=${id}`))
    );
  }

  addImportacao (cliente): Observable<Importacao> {
    
    return this.http.post<Importacao>(apiUrl, cliente, httpOptions).pipe(
      // tslint:disable-next-line:no-shadowed-variable
      tap((importacao: Importacao) => console.log(`adicionou o importacao com w/ id=${cliente.id}`)),
      //tap(_ => console.log(`adicionou o cliente`)),
      catchError(this.handleError<Importacao>('addImportacao'))
    );
  }

  /** POST: add a new file to the server */
  sendFile(file: any) : Observable<any> {
    return this.http.post(apiUrl, file, { responseType: 'text' })
        .pipe(tap(), catchError(this.handleError2<any>('base service add')));

    
  }
  
  private handleError2<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      alert("Erro ao importar planilha")

      return of(result as T);
    };
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      return of(result as T);
    };
  }
}