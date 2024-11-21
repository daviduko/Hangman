<%@ Page Title="Hangman Game" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hangman._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container my-5">
        <div class="text-center">
            <h1 class="mb-4">Hangman Game</h1>

            <div class="card shadow p-4">
                <!-- Display the hidden word -->
                <h3 class="mb-3">
                    <span class="text-primary">Word:</span>
                    <asp:Label ID="lblWord" runat="server" CssClass="text-dark"></asp:Label>
                </h3>

                <!-- Display remaining lives -->
                <p>
                    <strong class="text-danger">Lives Remaining:</strong>
                    <asp:Label ID="lblLives" runat="server" CssClass="text-danger"></asp:Label>
                </p>

                <!-- Display guessed letters -->
                <p>
                    <strong class="text-secondary">Guessed Letters:</strong>
                    <asp:Label ID="lblGuessedLetters" runat="server" CssClass="text-secondary"></asp:Label>
                </p>

                <!-- Input for guessing letters -->
                <div class="d-flex justify-content-center align-items-center mb-3">
                    <div class="input-group" style="max-width: 300px;">
                        <asp:TextBox ID="txtLetter" runat="server" CssClass="form-control" MaxLength="1" Placeholder="Enter a letter"></asp:TextBox>
                        <asp:Button CssClass="btn btn-primary" ID="btnGuess" runat="server" Text="Guess" OnClick="BtnGuess_Click" />
                    </div>
                </div>

                <!-- Display messages -->
                <asp:Label ID="lblMessage" runat="server" CssClass="text-warning"></asp:Label>

                <!-- New game button -->
                <div class="mt-3">
                    <button class="btn btn-success" runat="server" id="btnNewGame" OnClick="BtnNewGame_Click">Start New Game</button>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
