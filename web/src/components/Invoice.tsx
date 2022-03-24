const Invoice = (invoiceList: object[]) => {

  console.log(invoiceList)
  return (
    <ul>
      {invoiceList.map((item, index) => (
        <li key={index}>{item}</li>
      ))}
    </ul>
  );

};
export default Invoice;
