using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Module.CustomException
{
    public class CustomException:Exception
    {    
        public CustomException()
            : base() { }

        public CustomException(string message)
            : base(message) { }

        public CustomException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public CustomException(string message, Exception innerException)
            : base(message, innerException) { }

        public CustomException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
        
    }

    public class LoginFailedException : Exception
    {
        public LoginFailedException()
            : base() { }

        public LoginFailedException(string message)
            : base(message) { }

        public LoginFailedException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public LoginFailedException(string message, Exception innerException)
            : base(message, innerException) { }

        public LoginFailedException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

    }

    public class FilesRequestFailedException : Exception
    {
        public FilesRequestFailedException()
            : base() { }

        public FilesRequestFailedException(string message)
            : base(message) { }

        public FilesRequestFailedException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public FilesRequestFailedException(string message, Exception innerException)
            : base(message, innerException) { }

        public FilesRequestFailedException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

    }

    public class NoValidaDataException : Exception
    {
        public NoValidaDataException()
            : base() { }

        public NoValidaDataException(string message)
            : base(message) { }

        public NoValidaDataException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public NoValidaDataException(string message, Exception innerException)
            : base(message, innerException) { }

        public NoValidaDataException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

    }

    public class MappingFailedException : Exception
    {
        public MappingFailedException()
            : base() { }

        public MappingFailedException(string message)
            : base(message) { }

        public MappingFailedException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public MappingFailedException(string message, Exception innerException)
            : base(message, innerException) { }

        public MappingFailedException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

    }

    public class NotValidExtentionException : Exception
    {
        public NotValidExtentionException()
            : base() { }

        public NotValidExtentionException(string message)
            : base(message) { }

        public NotValidExtentionException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public NotValidExtentionException(string message, Exception innerException)
            : base(message, innerException) { }

        public NotValidExtentionException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

    }
}
