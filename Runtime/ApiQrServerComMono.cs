using System;
using System.Collections.Generic;


public class ApiQrServerComMono  : LoadQrFromUrlMono
{ 
    private void Reset()
    {
        m_serverUri = "https://api.qrserver.com/v1/create-qr-code/?size={1}x{1}&data={0}";
    }
}
