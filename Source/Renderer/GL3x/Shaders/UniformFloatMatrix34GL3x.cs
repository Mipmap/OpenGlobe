﻿#region License
//
// (C) Copyright 2009 Patrick Cozzi and Deron Ohlarik
//
// Distributed under the Boost Software License, Version 1.0.
// See License.txt or http://www.boost.org/LICENSE_1_0.txt.
//
#endregion

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenGlobe.Renderer;

namespace OpenGlobe.Renderer.GL3x
{
    internal class UniformFloatMatrix34GL3x : Uniform<Matrix34>, ICleanable
    {
        internal UniformFloatMatrix34GL3x(string name, int location, ICleanableObserver observer)
            : base(name, UniformType.FloatMatrix34)
        {
            _location = location;
            _dirty = true;
            _observer = observer;
            _observer.NotifyDirty(this);
        }

        #region Uniform<> Members

        public override Matrix34 Value
        {
            set
            {
                if (!_dirty && (_value != value))
                {
                    _dirty = true;
                    _observer.NotifyDirty(this);
                }

                _value = value;
            }

            get { return _value; }
        }

        #endregion

        #region ICleanable Members

        public void Clean()
        {
            Vector4 column0 = _value.Column0;
            Vector4 column1 = _value.Column1;
            Vector4 column2 = _value.Column2;

            float[] columnMajorElements = new float[] { 
            column0.X, column0.Y, column0.Z, column0.W, 
            column1.X, column1.Y, column1.Z, column1.W, 
            column2.X, column2.Y, column2.Z, column2.W };

            GL.UniformMatrix3x4(_location, 1, false, columnMajorElements);

            _dirty = false;
        }

        #endregion

        private int _location;
        private Matrix34 _value;
        private bool _dirty;
        private readonly ICleanableObserver _observer;
    }
}
