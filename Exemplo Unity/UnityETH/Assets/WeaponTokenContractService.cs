using System;
using System.Collections.Generic;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Hex.HexTypes;



public class WeaponTokenContractService {
	public static string ABI = @"[ 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_owner"", 				""type"": ""address"" 			} 		], 		""name"": ""getWeaponByOwner"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""uint256[]"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_interfaceId"", 				""type"": ""bytes4"" 			} 		], 		""name"": ""supportsInterface"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""bool"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [], 		""name"": ""name"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""string"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""getApproved"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""address"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [ 			{ 				""name"": ""_to"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""approve"", 		""outputs"": [], 		""payable"": false, 		""stateMutability"": ""nonpayable"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": """", 				""type"": ""uint256"" 			} 		], 		""name"": ""weaponToOwner"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""address"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [], 		""name"": ""totalSupply"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""uint256"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [], 		""name"": ""InterfaceId_ERC165"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""bytes4"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [ 			{ 				""name"": ""_from"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_to"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""transferFrom"", 		""outputs"": [], 		""payable"": false, 		""stateMutability"": ""nonpayable"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [ 			{ 				""name"": ""_name"", 				""type"": ""string"" 			} 		], 		""name"": ""buyRandomWeapon"", 		""outputs"": [], 		""payable"": true, 		""stateMutability"": ""payable"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_owner"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_index"", 				""type"": ""uint256"" 			} 		], 		""name"": ""tokenOfOwnerByIndex"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""uint256"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [ 			{ 				""name"": ""_from"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_to"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""safeTransferFrom"", 		""outputs"": [], 		""payable"": false, 		""stateMutability"": ""nonpayable"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""exists"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""bool"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_index"", 				""type"": ""uint256"" 			} 		], 		""name"": ""tokenByIndex"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""uint256"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": """", 				""type"": ""uint256"" 			} 		], 		""name"": ""weapons"", 		""outputs"": [ 			{ 				""name"": ""name"", 				""type"": ""string"" 			}, 			{ 				""name"": ""dna"", 				""type"": ""uint256"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""ownerOf"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""address"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_owner"", 				""type"": ""address"" 			} 		], 		""name"": ""balanceOf"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""uint256"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [], 		""name"": ""renounceOwnership"", 		""outputs"": [], 		""payable"": false, 		""stateMutability"": ""nonpayable"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [], 		""name"": ""owner"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""address"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [], 		""name"": ""symbol"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""string"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [ 			{ 				""name"": ""_to"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_approved"", 				""type"": ""bool"" 			} 		], 		""name"": ""setApprovalForAll"", 		""outputs"": [], 		""payable"": false, 		""stateMutability"": ""nonpayable"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [ 			{ 				""name"": ""_from"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_to"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			}, 			{ 				""name"": ""_data"", 				""type"": ""bytes"" 			} 		], 		""name"": ""safeTransferFrom"", 		""outputs"": [], 		""payable"": false, 		""stateMutability"": ""nonpayable"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [], 		""name"": ""getFeeValue"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""uint256"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [ 			{ 				""name"": ""weaponId1"", 				""type"": ""uint256"" 			}, 			{ 				""name"": ""weaponId2"", 				""type"": ""uint256"" 			} 		], 		""name"": ""constructWeapon"", 		""outputs"": [], 		""payable"": true, 		""stateMutability"": ""payable"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""tokenURI"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""string"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""_owner"", 				""type"": ""address"" 			}, 			{ 				""name"": ""_operator"", 				""type"": ""address"" 			} 		], 		""name"": ""isApprovedForAll"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""bool"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": true, 		""inputs"": [ 			{ 				""name"": ""weaponId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""getWeaponData"", 		""outputs"": [ 			{ 				""name"": """", 				""type"": ""string"" 			}, 			{ 				""name"": """", 				""type"": ""uint256"" 			} 		], 		""payable"": false, 		""stateMutability"": ""view"", 		""type"": ""function"" 	}, 	{ 		""constant"": false, 		""inputs"": [ 			{ 				""name"": ""_newOwner"", 				""type"": ""address"" 			} 		], 		""name"": ""transferOwnership"", 		""outputs"": [], 		""payable"": false, 		""stateMutability"": ""nonpayable"", 		""type"": ""function"" 	}, 	{ 		""anonymous"": false, 		""inputs"": [ 			{ 				""indexed"": false, 				""name"": ""weaponId"", 				""type"": ""uint256"" 			}, 			{ 				""indexed"": false, 				""name"": ""name"", 				""type"": ""string"" 			}, 			{ 				""indexed"": false, 				""name"": ""dna"", 				""type"": ""uint256"" 			} 		], 		""name"": ""NewWeapon"", 		""type"": ""event"" 	}, 	{ 		""anonymous"": false, 		""inputs"": [ 			{ 				""indexed"": true, 				""name"": ""previousOwner"", 				""type"": ""address"" 			} 		], 		""name"": ""OwnershipRenounced"", 		""type"": ""event"" 	}, 	{ 		""anonymous"": false, 		""inputs"": [ 			{ 				""indexed"": true, 				""name"": ""previousOwner"", 				""type"": ""address"" 			}, 			{ 				""indexed"": true, 				""name"": ""newOwner"", 				""type"": ""address"" 			} 		], 		""name"": ""OwnershipTransferred"", 		""type"": ""event"" 	}, 	{ 		""anonymous"": false, 		""inputs"": [ 			{ 				""indexed"": true, 				""name"": ""_from"", 				""type"": ""address"" 			}, 			{ 				""indexed"": true, 				""name"": ""_to"", 				""type"": ""address"" 			}, 			{ 				""indexed"": true, 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""Transfer"", 		""type"": ""event"" 	}, 	{ 		""anonymous"": false, 		""inputs"": [ 			{ 				""indexed"": true, 				""name"": ""_owner"", 				""type"": ""address"" 			}, 			{ 				""indexed"": true, 				""name"": ""_approved"", 				""type"": ""address"" 			}, 			{ 				""indexed"": true, 				""name"": ""_tokenId"", 				""type"": ""uint256"" 			} 		], 		""name"": ""Approval"", 		""type"": ""event"" 	}, 	{ 		""anonymous"": false, 		""inputs"": [ 			{ 				""indexed"": true, 				""name"": ""_owner"", 				""type"": ""address"" 			}, 			{ 				""indexed"": true, 				""name"": ""_operator"", 				""type"": ""address"" 			}, 			{ 				""indexed"": false, 				""name"": ""_approved"", 				""type"": ""bool"" 			} 		], 		""name"": ""ApprovalForAll"", 		""type"": ""event"" 	} ]";

	private static string contractAddress = "0xaeAD2C7d3a1ed6378A4D067bA7F04498Ad6716dA";

	private Contract contract;

	public WeaponTokenContractService () {
		this.contract = new Contract (null, ABI, contractAddress);
		
	}

	public Function GetBuyRandomWeaponFunction () {
		return contract.GetFunction ("buyRandomWeapon");
	}

	public Function GetWeaponByOwnerFunction () {
		return contract.GetFunction ("getWeaponByOwner");
	}
	
	public Function GetWeaponFunction ()
	{
		return contract.GetFunction ("weapons");
	}

	public TransactionInput BuyRandomWeapon (
		string addressFrom,
		HexBigInteger gas = null,
		HexBigInteger gasPrice = null,
		HexBigInteger valueAmount = null,
		String name = null) {

		var function = GetBuyRandomWeaponFunction ();
		return function.CreateTransactionInput (addressFrom, gas, gasPrice, valueAmount, name);
	}

	public CallInput CreateGetWeaponByOwnerCallInput (string addressFrom) {
		
		var function = GetWeaponByOwnerFunction ();
		return function.CreateCallInput (addressFrom);
	}
	
	public List<int> DecodeGetWeaponByOwner (string result) {
		var function = GetWeaponByOwnerFunction ();
		return function.DecodeSimpleTypeOutput<List<int>> (result);
	}
	
	public CallInput GetWeaponCallInput (int id) {
		var function = GetWeaponFunction ();
		return function.CreateCallInput (id);
	}
	

	public String DecodeWeapon (string result) {
		var function = GetWeaponFunction ();
		return function.DecodeSimpleTypeOutput<String> (result);
	}
}