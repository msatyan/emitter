// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Emitter.Network.Native;

namespace Emitter.Network
{
    /// <summary>
    /// An implementation of <see cref="ListenerSecondary"/> using TCP sockets.
    /// </summary>
    internal class TcpListenerSecondary : ListenerSecondary
    {
        public TcpListenerSecondary(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        /// <summary>
        /// Creates a socket which can be used to accept an incoming connection
        /// </summary>
        protected override UvStreamHandle CreateAcceptSocket()
        {
            var acceptSocket = new UvTcpHandle();
            acceptSocket.Init(Thread.Loop, Thread.QueueCloseHandle);
            acceptSocket.NoDelay(true);
            acceptSocket.KeepAlive(true);
            return acceptSocket;
        }
    }
}