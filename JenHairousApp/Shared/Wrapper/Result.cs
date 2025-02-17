﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenHairousApp.Shared.Wrapper
{
    public class Result : IResult
    {
        public Result()
        {
        }

        public bool                     Failed                  => !Succeeded;

        public List<string>             Messages                { get; set; } = new List<string>();

        public bool                     Succeeded               { get; set; }

        public static IResult Fail()
        {
            return new Result { Succeeded = false };
        }

        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Messages = new List<string> { message } };
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }

        public static IResult Success(string message)
        {
            return new Result { Succeeded = true, Messages = new List<string> { message } };
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public Result()
        {
        }

        public T Data { get; set; }

        public static new Result<T> Fail()
        {
            return new Result<T> { Succeeded = false };
        }

        public static new Result<T> Fail(string message)
        {
            return new Result<T> { Succeeded = false, Messages = new List<string> { message } };
        }

        public static new Result<T> Success()
        {
            return new Result<T> { Succeeded = true };
        }

        public static new Result<T> Success(string message)
        {
            return new Result<T> { Succeeded = true, Messages = new List<string> { message } };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T> { Succeeded = true, Data = data };
        }

        public static Result<T> Success(T data, string message)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };
        }
    }
}
