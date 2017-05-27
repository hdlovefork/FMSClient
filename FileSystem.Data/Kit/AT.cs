/**************************************************************** 
 * 作    者：顾挺
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-11 14:13:04 
 * 当前版本：1.0.0.0
 *  
 * 描述说明： 
 *     为学员提供一个容易操作的多线程异步操作类
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ Dean 2017 All rights reserved 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileSystem.Data
{
    /// <summary>
    /// AT即AsyncTask（异步任务的缩写）
    /// </summary>
    public class AT : BTask
    {
        /// <summary>
        /// 创建无返回值的一个异步任务
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static VTask Create(Action action)
        {
            return new VTask(action);
        }

        /// <summary>
        /// 创建一个有返回值的异步任务，返回值的类型为<typeparamref name="TResult"/>
        /// </summary>
        /// <typeparam name="TResult">任务的返回值类型</typeparam>
        /// <param name="fun">有返回值的任务</param>
        /// <returns></returns>
        public static RTask<TResult> Create<TResult>(Func<TResult> fun)
        {
            return new RTask<TResult>(fun);
        }
    }

    public class BTask
    {
        /// <summary>
        /// 当Run方法没有处理异常时，实现该方法统一处理异常
        /// </summary>
        /// <param name="ex"></param>
        public virtual void HandleException(Exception ex)
        {
            Console.WriteLine("{0}\n{1}\n{2}", ex.Source, ex.StackTrace, ex.Message);
        }
    }

    /// <summary>
    /// 有返回值的Task
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RTask<T> : BTask
    {
        private Task<T> mTask;
        public RTask(Func<T> func)
        {
            mTask = new Task<T>(func);
        }

        /// <summary>
        /// 执行一个有返回值的异步任务
        /// </summary>
        /// <typeparam name="T">Create方法的返回值类型</typeparam>
        /// <param name="success">Create方法执行成功后调用该方法并传入返回值</param>
        /// <param name="error">Create方法出现异常时的处理方法</param>
        /// <param name="complete">Create方法执行完成时调用该方法，一般用于资源回收如：关闭对话框操作</param>
        public void Run(Action<T> success, Action complete, Action<Exception> error)
        {
            mTask.Start();
            mTask.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    error(t.Exception.GetBaseException());
                else
                    success(((Task<T>)mTask).Result);
                complete();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// 执行一个有返回值的异步任务
        /// </summary>
        /// <typeparam name="T">Create方法的返回值类型</typeparam>
        /// <param name="success">Create方法执行成功后调用该方法并传入返回值</param>
        public void Run(Action<T> success)
        {
            mTask.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    HandleException(t.Exception.GetBaseException());//子类实现异常处理
                }
                else
                    success(((Task<T>)mTask).Result);
            }, TaskScheduler.FromCurrentSynchronizationContext());
            mTask.Start();
        }

        /// <summary>
        /// 执行一个有返回值的异步任务
        /// </summary>
        /// <typeparam name="T">Create方法的返回值类型</typeparam>
        /// <param name="success">Create方法执行成功后调用该方法并传入返回值</param>       
        /// <param name="complete">Create方法执行完成时调用该方法，一般用于资源回收如：关闭对话框操作</param>
        public void Run(Action<T> success, Action complete)
        {
            mTask.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    HandleException(t.Exception.GetBaseException());//子类实现异常处理
                }
                else
                    success(((Task<T>)mTask).Result);
                complete();
            }, TaskScheduler.FromCurrentSynchronizationContext());
            mTask.Start();
        }
    }

    /// <summary>
    /// 无返回值的Task
    /// </summary>
    public class VTask : BTask
    {
        private Task mTask;
        public VTask(Action action)
        {
            mTask = new Task(action);
        }

        /// <summary>
        ///执行一个无返回值的异步任务
        /// </summary>
        /// <param name="success">Create方法执行成功后调用该方法</param>
        /// <param name="complete">Create方法执行完成时调用该方法，一般用于资源回收如：关闭对话框操作</param>
        /// <param name="error">Create方法出现异常时的处理方法</param>
        public void Run(Action success, Action complete, Action<Exception> error)
        {
            mTask.Start();
            mTask.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    error(t.Exception.GetBaseException());
                else
                {
                    if (success != null)
                        success();
                }
                if (complete != null)
                    complete();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        /// <summary>
        /// 执行一个无返回值的异步任务
        /// </summary>
        /// <param name="success">Create方法执行成功后调用该方法</param>
        public void Run(Action success)
        {
            mTask.Start();
            mTask.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    HandleException(t.Exception.GetBaseException());//子类实现异常处理
                }
                else
                {
                    if (success != null)
                        success();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        ///  执行一个无返回值的异步任务
        /// </summary>
        /// <param name="success">Create方法执行成功后调用该方法</param>
        /// <param name="complete">Create方法执行完成时调用该方法，一般用于资源回收如：关闭对话框操作</param>
        public void Run(Action success, Action complete)
        {
            mTask.Start();
            mTask.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    HandleException(t.Exception.GetBaseException());
                else
                {
                    if (success != null)
                        success();
                }
                if (complete != null)
                    complete();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        /// <summary>
        /// 执行一个无返回值的异步任务
        /// </summary>
        public void Run()
        {
            mTask.Start();
            mTask.ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    HandleException(t.Exception.GetBaseException());
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }

}
