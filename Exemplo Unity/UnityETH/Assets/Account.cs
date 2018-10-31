using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Nethereum.JsonRpc.UnityClient;
using Nethereum.Hex.HexTypes;
using System;
using System.Collections.Generic;


public class Account : MonoBehaviour {
	private string accountAddress;
	private string accountPrivateKey = "0x3920636D4DABED5D050904DF872850DE917877484372D3FDAC4A01C6FDF67A04";
	private string _url = "https://kovan.infura.io";

	private WeaponTokenContractService _weaponTokenContractService = new WeaponTokenContractService ();

	void Start () {
		importAccountFromPrivateKey ();

		
		StartCoroutine (BuyRandomWeaponTransaction ());
		
		StartCoroutine (GetWeaponByOwnerTransaction ());
		
		StartCoroutine (GetWeaponTransaction ());


		StartCoroutine(getAccountBalance(accountAddress, (balance) => {
			Debug.Log("Account balance: " + balance);
		}));

		
		var createNewAccount = false;
		if (createNewAccount == true) {
			CreateAccount ("strong_password", (address, encryptedJson) => {
				Debug.Log (address);
				Debug.Log (encryptedJson);
				StartCoroutine (getAccountBalance (address, (balance) => {
					Debug.Log (balance); // This will always give you 0, except if you are imposibly lucky.
				}));
			});
		}

	}


	public IEnumerator BuyRandomWeaponTransaction () {
	
		var transactionInput = _weaponTokenContractService.BuyRandomWeapon (
			accountAddress,
			new HexBigInteger (8000000),
			new HexBigInteger (500),
			new HexBigInteger (1000000000000000),
			"Excalibur"
		);

		var transactionSignedRequest = new TransactionSignedUnityRequest (_url, accountPrivateKey, accountAddress);

		Debug.Log("Sending Buy Weapon transaction...");
		yield return transactionSignedRequest.SignAndSendTransaction (transactionInput);
		if (transactionSignedRequest.Exception == null) {
			Debug.Log ("Buy Weapon tx submitted: " + transactionSignedRequest.Result);
		} else {
			Debug.Log ("Error submitting Buy Weapon tx: " + transactionSignedRequest.Exception.Message);
		}
	}
	
	public IEnumerator GetWeaponByOwnerTransaction () {
		var request = new EthCallUnityRequest (_url);

		var callInput = _weaponTokenContractService.CreateGetWeaponByOwnerCallInput (accountAddress);
		Debug.Log ("Getting GetWeaponByOwner...");
		
		yield return request.SendRequest (callInput, Nethereum.RPC.Eth.DTOs.BlockParameter.CreateLatest ());

		if (request.Exception == null) {
			Debug.Log ("GetWeaponByOwnerTransaction (HEX): " + request.Result);
			List<int> lista = _weaponTokenContractService.DecodeGetWeaponByOwner(request.Result);
			foreach (var l in lista)
			{
				Debug.Log ("GetWeaponByOwnerTransaction:" + l);
			}
			
		} else {
			Debug.Log ("Error submitting GetWeaponByOwnerTransaction tx: " + request.Exception.Message);
		}
	}

	public IEnumerator GetWeaponTransaction () {
		var request = new EthCallUnityRequest (_url);

		var callInput = _weaponTokenContractService.GetWeaponCallInput (0);
		Debug.Log ("Getting GetWeaponCallInput...");
		
		yield return request.SendRequest (callInput, Nethereum.RPC.Eth.DTOs.BlockParameter.CreateLatest ());

		if (request.Exception == null) {
			Debug.Log ("GetWeaponCallInput (HEX): " + request.Result);
			String w = _weaponTokenContractService.DecodeWeapon(request.Result);
			Debug.Log ("GetWeaponCallInput):" + w);
		} else {
			Debug.Log ("Error submitting GetWeaponCallInput tx: " + request.Exception.Message);
		}
	}


	public void importAccountFromPrivateKey () {
		try {
			var address = Nethereum.Signer.EthECKey.GetPublicAddress (accountPrivateKey);
			accountAddress = address;
			Debug.Log("Public adress: " + accountAddress);
		} catch (Exception e) {
			Debug.Log("Error importing account from PrivateKey: " + e);
		}
	}



	
	public void CreateAccount (string password, System.Action<string, string> callback) {
		var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
		var address = ecKey.GetPublicAddress();
		var privateKey = ecKey.GetPrivateKeyAsBytes();

		var addr = Nethereum.Signer.EthECKey.GetPublicAddress(privateKey.ToString());
		var keystoreservice =  new Nethereum.KeyStore.KeyStoreService();
		var encryptedJson = keystoreservice.EncryptAndGenerateDefaultKeyStoreAsJson (password, privateKey, address);

		callback (address, encryptedJson);
	}

	public IEnumerator getAccountBalance (string address, System.Action<decimal> callback) {
		var getBalanceRequest = new EthGetBalanceUnityRequest (_url);
		yield return getBalanceRequest.SendRequest(address, Nethereum.RPC.Eth.DTOs.BlockParameter.CreateLatest ());
		if (getBalanceRequest.Exception == null) {
			var balance = getBalanceRequest.Result.Value;
			callback (Nethereum.Util.UnitConversion.Convert.FromWei(balance, 18));
		} else {
			throw new System.InvalidOperationException ("Get balance request failed");
		}

	}

}