using Sharprompt;
using System;
using EPDM.Interop.epdm;
using System.Collections.Generic;

namespace PDM_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> vaultViewNames = new List<string>(); 
            EdmViewInfo[] vaultViewInfos = null;

            IEdmVault5 vault5 = new EdmVault5();
            IEdmVault8 vault8 = (IEdmVault8)vault5;

            Console.WriteLine($"Welcome to the PDM CLI.");

            vault8.GetVaultViews(out vaultViewInfos, false);


            foreach (EdmViewInfo viewInfo in vaultViewInfos)
            {
                vaultViewNames.Add(viewInfo.mbsVaultName);
            }
            
            var vault_selected = Prompt.Select<string>("Which vault would you like to use?", vaultViewNames);
            
            Console.WriteLine($"The vault selected is {vault_selected}");
        }
    }
}
