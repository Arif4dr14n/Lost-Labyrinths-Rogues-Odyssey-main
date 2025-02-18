using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpsLeft;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        : base(player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps; // Set awal jumlah loncatan.
    }

    public override void Enter()
    {
        base.Enter();

        // Gunakan input lompatan dan kurangi jumlah lompatan yang tersisa
        player.InputHandler.UseJumpInput();
        PerformJump();
    }

    private void PerformJump()
    {
        if (amountOfJumpsLeft > 0)
        { // Jika masih ada lompatan tersisa
            Movement?.SetVelocityY(playerData.jumpVelocity); // Berikan kecepatan lompatan
            amountOfJumpsLeft--; // Kurangi jumlah lompatan
            player.InAirState.SetIsJumping(); // Tandai bahwa karakter sedang melompat
            isAbilityDone = true; // Tandai selesai
        }
    }


    public bool CanJump()
    {
        return amountOfJumpsLeft > 0; // Karakter bisa melompat jika masih ada lompatan tersisa.
    }

    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = playerData.amountOfJumps;

    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;
}
