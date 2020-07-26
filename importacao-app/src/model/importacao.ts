import { DecimalPipe } from '@angular/common';

export class Importacao {
    id: number;
    dataEntrega: string;
    nomeProduto: string;
    quantidade: number;
    valorUnitario: number;
    valorTotal: number;
  }