export interface CreateOrderRequest {
  custid: number;
  empid: number;
  shipperid: number;
  shipname: string;
  shipaddress: string;
  shipcity: string;
  orderdate: string;
  requireddate: string;
  shippeddate: string;
  freight: number;
  shipcountry: string;
  productid: number;
  unitprice: number;
  qty: number;
  discount: number;
}