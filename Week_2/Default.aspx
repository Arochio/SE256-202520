<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Week_2._Default" %>

<asp:Content ID="AlbumContent" ContentPlaceHolderID="latestAlbum" runat="server">

    <h2>Latest Album</h2>
    <p>Nothing released yet.</p>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="BottomContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Home</h1>
            <p class="lead">GraveSongs is the newest way to track music releases and reviews.</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="songsTitle">
                <h2 id="songsTitle">Songs</h2>
                <p>
                    Read listener interpretations of songs or rate the songs you love or hate.
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="artistTitle">
                <h2 id="artistTitle">Artists</h2>
                <p>
                    See when your favorite artists last released music.
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="moreTitle">
                <h2 id="moreTitle">More</h2>
                <p>
                    More features are always coming to GraveSongs, stay tuned for more.
                </p>
            </section>
        </div>
    </main>

</asp:Content>
