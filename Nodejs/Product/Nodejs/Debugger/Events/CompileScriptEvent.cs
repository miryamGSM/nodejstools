﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using Microsoft.NodejsTools.Debugger.Serialization;
using Newtonsoft.Json.Linq;

namespace Microsoft.NodejsTools.Debugger.Events {
    sealed class CompileScriptEvent : IDebuggerEvent {
        public CompileScriptEvent(JObject message) {
            Running = (bool)message["running"];

            var scriptId = (int)message["body"]["script"]["id"];
            string fileName = (string)message["body"]["script"]["name"] ?? NodeVariableType.UnknownModule;

            Module = new NodeModule(scriptId, fileName);
        }

        public NodeModule Module { get; private set; }
        public bool Running { get; private set; }
    }
}