public class QuickChartIoMono : LoadQrFromUrlMono
{
    private void Reset()
    {
        m_serverUri = "https://quickchart.io/qr?size={1}x{1}&text={0}";
    }
}
