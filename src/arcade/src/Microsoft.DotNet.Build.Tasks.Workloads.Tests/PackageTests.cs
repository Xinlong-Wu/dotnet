// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.Deployment.DotNet.Releases;
using Xunit;

namespace Microsoft.DotNet.Build.Tasks.Workloads.Tests
{
    [Collection("6.0.200 Toolchain manifest tests")]
    public class PackageTests : TestBase
    {
        [WindowsOnlyFact]
        public void ItCanReadAManifestPackage()
        {
            string PackageRootDirectory = Path.Combine(BaseIntermediateOutputPath, "pkg");

            TaskItem manifestPackageItem = new(Path.Combine(TestAssetsPath, "microsoft.net.workload.mono.toolchain.manifest-6.0.300.6.0.22.nupkg"));
            WorkloadManifestPackage p = new(manifestPackageItem, PackageRootDirectory, new Version("1.2.3"));

            ReleaseVersion expectedFeatureBand = new("6.0.300");

            Assert.Equal("Microsoft.NET.Workload.Mono.ToolChain", p.ManifestId);
            Assert.Equal(expectedFeatureBand, p.SdkFeatureBand);
        }

        [WindowsOnlyTheory]
        [InlineData("Microsoft.NET.Workload.Emscripten.net6.Manifest-8.0.100-alpha.1", WorkloadManifestPackage.ManifestSeparator, "8.0.100-alpha.1")]
        [InlineData("Microsoft.NET.Workload.Emscripten.Manifest-8.0.100-alpha.1.23062.6", WorkloadManifestPackage.ManifestSeparator, "8.0.100-alpha.1.23062.6")]
        [InlineData("Microsoft.NET.Workloads.8.0.100-preview.7.23376.3", WorkloadSetPackage.SdkFeatureBandSeparator, "8.0.100-preview.7.23376.3")]
        [InlineData("Microsoft.NET.Workloads.8.0.100", WorkloadSetPackage.SdkFeatureBandSeparator, "8.0.100")]
        public static void ItExtractsTheSdkVersionFromThePackageId(string packageId, string separator, string expectedVersion)
        {
            string actualSdkVersion = WorkloadPackageBase.GetSdkVersion(packageId, separator);

            Assert.Equal(expectedVersion, actualSdkVersion);
        }

        [WindowsOnlyFact]
        public void ItThrowsIfTheMsiVersionIsInvalid()
        {
            string PackageRootDirectory = Path.Combine(BaseIntermediateOutputPath, "wls-pkg");

            ITaskItem workloadSetPackageItem = new TaskItem(Path.Combine(TestAssetsPath, "microsoft.net.workloads.9.0.100.9.0.100-baseline.1.23464.1.nupkg"));

            Assert.Throws<ArgumentOutOfRangeException>(() => { WorkloadSetPackage p = new(workloadSetPackageItem, PackageRootDirectory, new Version("256.12.3")); });
        }
    }
}
