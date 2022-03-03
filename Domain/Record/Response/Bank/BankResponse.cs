using System;
using System.Collections.Generic;

namespace Domain.Record.Response.Bank;

public class BankResponse
{
    public List<Result> result { get; set; }
    public object errorMessage { get; set; }
    public object errorMessages { get; set; }
    public bool hasError { get; set; }
    public DateTime timeGenerated { get; set; }

}
public class Result
{
    public string bankName { get; set; }
    public string bankCode { get; set; }
}