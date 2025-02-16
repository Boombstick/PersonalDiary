namespace PersonalDiary.Api.Middlewares
{
    public class RequestLoggerMiddleware : IMiddleware
    {
        private readonly ILogger<RequestLoggerMiddleware> _logger;
        private readonly string _logFilePath;
        private readonly object _locker = new object();
        public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger, IHostEnvironment env)
        {
            _logger = logger;
            var logDirectory = Path.Combine(env.ContentRootPath, "Logs");
            Directory.CreateDirectory(logDirectory);
            // Файл логов будет с датой в названии (новый файл каждый день)
            _logFilePath = Path.Combine(logDirectory, $"log-{DateTime.UtcNow:yyyyMMdd}.txt");
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Записываем информацию о входящем запросе
            var requestLog = $"[{DateTime.UtcNow:O}] Request: {context.Request.Method} {context.Request.Path}{Environment.NewLine}";
            WriteLog(requestLog);

            try
            {
                // Передаём управление следующему middleware в конвейере
                await next(context);
            }
            catch (Exception ex)
            {
                // Логируем ошибку с сообщением и стеком вызовов
                var errorLog = $"[{DateTime.UtcNow:O}] Error: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";
                WriteLog(errorLog);

                // Перебрасываем исключение, чтобы его можно было обработать дальше, если требуется
                throw;
            }

            // После обработки запроса логируем статус ответа
            var responseLog = $"[{DateTime.UtcNow:O}] Response: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path}{Environment.NewLine}";
            WriteLog(responseLog);
        }
        private void WriteLog(string message)
        {
            lock (_locker)
            {
                File.AppendAllText(_logFilePath, message);
            }
        }
    }
}
