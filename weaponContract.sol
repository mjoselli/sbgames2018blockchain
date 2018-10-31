pragma solidity ^0.4.21;


import "github.com/OpenZeppelin/zeppelin-solidity/contracts/token/ERC721/ERC721Token.sol";
import "github.com/OpenZeppelin/zeppelin-solidity/contracts/ownership/Ownable.sol";



contract WeaponToken is ERC721Token("WeaponToken","WEAPON"), Ownable {
  event NewWeapon(uint weaponId, string name, uint dna);

  uint dnaDigits = 16;
  uint dnaModulus = 10 ** dnaDigits;
  
  uint creationUpFee = 0.001 ether;
  
  struct Weapon {
    string name;
    uint dna;
  }


  Weapon[] public weapons;
  mapping (uint => address) public weaponToOwner;
  mapping (address => uint) ownerWeaponCount;

  function _createWeapon(string _name, uint _dna) internal {
    uint id = weapons.push(Weapon(_name, _dna)) - 1;
    weaponToOwner[id] = msg.sender;
    ownerWeaponCount[msg.sender]++;
    emit NewWeapon(id, _name, _dna);
  }
  function _generateRandomDna(string _str) private view returns (uint) {
    uint rand = uint(keccak256(abi.encodePacked(_str)));
    return rand % dnaModulus;
  }
  function buyRandomWeapon(string _name) external payable {   
    require(msg.value == creationUpFee);
    _createWeapon(_name,_generateRandomDna(_name));
  }


  
  function getWeaponByOwner(address _owner) external view returns(uint[]) {
    uint[] memory result = new uint[](ownerWeaponCount[_owner]);
    uint counter = 0;
    for (uint i = 0; i < weapons.length; i++) {
      if (weaponToOwner[i] == _owner) {
        result[counter] = i;
        counter++;
      }
    }
    return result;
  }
  
  function getWeaponData(uint weaponId) external view returns(string, uint) {
    return (weapons[weaponId].name,weapons[weaponId].dna);
  }

}