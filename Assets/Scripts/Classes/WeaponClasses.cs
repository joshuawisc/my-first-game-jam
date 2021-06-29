using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    public class BasePistol : IRangedWeapon
    {
        #region FIELDS
        #endregion

        #region PROPERTIES
        public float ReloadSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MagazineSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FXName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int baseDamage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float attackSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string ItemID => throw new NotImplementedException();

        public GameObject InGameObject => throw new NotImplementedException();

        public string InstanceID => throw new NotImplementedException();

        public string Type => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();
        #endregion

        #region PUBLIC METHODS
        public void Despawn()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }

        public void Equip()
        {
            throw new NotImplementedException();
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }

        public void Spawn(Vector3 input)
        {
            throw new NotImplementedException();
        }

        public void Store()
        {
            throw new NotImplementedException();
        }

        public void Use()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PRIVATE METHODS
        #endregion
    }
}
