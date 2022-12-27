namespace Business.Models;

public class MessageResponse : Error
{
    public string recipient_id { get; set; }
    public string message_id { get; set; }
    public string attachment_id { get; set; }
}


public class Error
{
    public ErrorMessage error { get; set; }
}

public class ErrorMessage
{
    public string type { get; set; }
    public int code { get; set; }
    public string message { get; set; }
    public string fbtrace_id { get; set; }
    public string error_user_msg { get; set; }
    public string error_subcode { get; set; }
    public string recipient_id { get; set; }
    public string full_name { get; set; }
}
    
public class ErrorTimeout
{
    public string errorMessage { get; set; }
    public string recipientId { get; set; }
    public string recipientName { get; set; }

    public static ErrorTimeout From(string errorMessage, string recipientId, string recipientName)
    {
        return new ErrorTimeout
        {
            errorMessage = errorMessage,
            recipientId = recipientId,
            recipientName = recipientName
        };
    }

    public override string ToString()
    {
        return errorMessage;
    }
}